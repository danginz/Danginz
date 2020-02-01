namespace Danginz.Core

open FSharp.Data

module LionsDenParser =

    type CompendiumXml = XmlProvider<Schema = "./lions-den-xsd/compendium.xsd">

    type ParsedItem =
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

    type ClassFeature =
        { Optional: bool
          Name: string option
          Texts: string array }

    type ClassAutoLevel =
        { Level: int option
          Features: ClassFeature array }

    type ParsedClass =
        { Name: string option
          Hd: string option
          Proficiency: string option
          SpellAbility: string option
          AutoLevels: ClassAutoLevel array }

    type ParsedCompendium =
        { Items: ParsedItem array
          Races: unit
          Spells: unit
          Monsters: unit
          Classes: ParsedClass array }

    let parseTexts =
        Array.map (fun t -> if t = "" then "\n" else t.Trim())

    let parseXmlMonsters = ()

    let parseXmlRaces = ()

    let parseXmlSpells = ()

    let parseXmlItems (xmlItems: CompendiumXml.Item array) =
        xmlItems
        |> Array.map (fun item ->
              { Name = item.Names |> Array.tryItem 0
                Type = item.Types |> Array.tryItem 0
                Magic = if item.Magics |> Array.tryItem 0 |> Option.isNone then false else true
                Value = item.Values |> Array.tryItem 0
                Texts = parseTexts item.Texts
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

    let parseXmlClasses (xmlClasses: CompendiumXml.Class array) =
        xmlClasses
        |> Array.map (fun class_ ->
            { Name = Some class_.Name
              Hd = None
              Proficiency = None
              SpellAbility = None
              AutoLevels = class_.Autolevels |> Array.map (fun autolevel ->
                  { Level = autolevel.Level |> Option.map (fun s -> int s)
                    Features = autolevel.Features |> Array.map (fun feature ->
                        { Optional =
                            feature.Optional
                            |> Option.map (fun str -> if str.ToLower() = "yes" then true else false)
                            |> Option.defaultValue false
                          Name = Some feature.Name
                          Texts = parseTexts feature.Texts }) }) })

    let parseCompendiumXml xml =
        let doc = CompendiumXml.Parse xml

        if doc.Version <> Some "5"
        then Error "Can only parse v5 Compendium files"
        else
            let compendium =
                { Items = parseXmlItems doc.Items
                  Spells = ()
                  Monsters = ()
                  Classes = parseXmlClasses doc.Classes
                  Races = () }

            Ok compendium
