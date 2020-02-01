namespace Danginz.Core

open FSharp.Data

module LionsDenParser =

    type ItemXml = XmlProvider<Schema = "./lions-den-xsd/item.xsd">
    type SpellXml = XmlProvider<Schema = "./lions-den-xsd/spell.xsd">
    type MonsterXml = XmlProvider<Schema = "./lions-den-xsd/monster.xsd">
    type CompendiumXml = XmlProvider<Schema = "./lions-den-xsd/compendium.xsd">

    type ParsedSimpleItem =
        { Name: string option
          Type: string option
          Weight: string option
          Magic: bool
          Value: string option
          Texts: string array
          Ac: int option
          Rarity: string option
          Stealth: bool
          Rolls: string array
          Modifiers: string array }

    type ParsedCompendium =
        { Items: ParsedSimpleItem array }

    let parseCompendiumXml xml =
        let doc = CompendiumXml.Parse xml

        if doc.Version <> Some "5"
        then Error "Can only parse v5 Compendium files"
        else Ok ""


    let parseItemXml xml =
        let doc = ItemXml.Parse xml

        match doc.Version with
        | Some "5" ->
            let items =
                doc.Items
                |> Array.map (fun item ->
                      { Name = item.Names |> Array.tryItem 0
                        Type = item.Types |> Array.tryItem 0
                        Magic = if item.Magics |> Array.tryItem 0 |> Option.isNone then false else true
                        Value = item.Values |> Array.tryItem 0
                        Texts = item.Texts |> Array.map (fun t -> if t = "" then "\n" else t.Trim())
                        Ac = item.Acs |> Array.tryItem 0 |> Option.map (fun s -> int s)
                        Rarity = item.Rarities |> Array.tryItem 0
                        Weight = item.Weights |> Array.tryItem 0
                        Stealth =
                          item.Stealths
                          |> Array.tryItem 0
                          |> Option.map (fun s -> if s.ToLower() = "yes" then true else false)
                          |> Option.defaultValue false
                        Rolls = item.Rolls
                        Modifiers = item.Modifiers |> Array.map (fun m -> m.Value) })
            Ok items
        | _ -> Error "Can only parse v5 Compendium files"
