open Danginz.Core

[<EntryPoint>]
let main _argv =
    printfn "[Danginz.Core] Started!"
    let result = LionsDenParser.parseItemXml """<?xml version='1.0' encoding='UTF-8'?>
<compendium version="5">

<item>
<name>10 GP - Azurite</name>
<type>$</type>
<magic />
<value>10gp</value>
<weight>0</weight>
<text>An opaque mottled deep blue gemstone worth 10 gp.</text>
<text />
<text>Source: Dungeon Master's Guide, page 134</text>
</item>

<item>
<name>Arrows +2</name>
<type>A</type>
<magic>1</magic>
<weight>0.05</weight>
<rarity>Rare</rarity>
<text>Rarity: Rare</text>
<text>	You have a +2 bonus to attack and damage rolls made with this piece of magic ammunition. Once it hits a target, the ammunition is no longer magical.</text>
<text />
<text>Source: Dungeon Master's Guide, page 150</text>
<modifier category="bonus">ranged attacks +2</modifier>
<modifier category="bonus">ranged damage +2</modifier>
</item>

<item>
<name>Berserker Battleaxe</name>
<type>M</type>
<magic>1</magic>
<weight>4</weight>
<dmg1>1d8</dmg1>
<dmg2>1d10</dmg2>
<dmgType>S</dmgType>
<property>V</property>
<rarity>Rare</rarity>
<text>Rarity: Rare</text>
<text>Requires Attunement</text>
<text>	You gain a +1 bonus to attack and damage rolls made with this magic weapon. In addition, while you are attuned to this weapon, your hit point maximum increases by 1 for each level you have attained.</text>
<text />
<text>Curse: This axe is cursed, and becoming attuned to it extends the curse to you. As long as you remain cursed, you are unwilling to part with the axe, keeping it within reach at all times. You also have disadvantage on attack rolls with weapons other than this one, unless no foe is within 60 feet of you that you can see or hear.</text>
<text>Whenever a hostile creature damages you while the axe is in your possession, you must succeed on a DC 15 Wisdom saving throw or go berserk. While berserk, you must use your action each round to attack the creature nearest to you with the axe. If you can make extra attacks as part of the Attack action, you use those extra attacks, moving to attack the next nearest creature after you fell your current target. If you have multiple possible targets, you attack one at random. You are berserk until you start your turn with no creatures within 60 feet of you that you can see or hear.</text>
<text />
<text>Versatile: This weapon can be used with one or two hands. A damage value in parentheses appears with the property — the damage when the weapon is used with two hands to make a melee attack.</text>
<text />
<text>Source: Dungeon Master's Guide, page 155</text>
<modifier category="bonus">melee attacks +1</modifier>
<modifier category="bonus">melee damage +1</modifier>
</item>

<item>
<name>Chain Mail of Thunder Resistance</name>
<type>HA</type>
<magic>1</magic>
<weight>55</weight>
<ac>16</ac>
<strength>13</strength>
<stealth>YES</stealth>
<rarity>Rare</rarity>
<text>Rarity: Rare</text>
<text>Requires Attunement</text>
<text>	You have resistance to thunder damage while you wear this armor.</text>
<text />
<text>Source: Dungeon Master's Guide, page 152</text>
</item>

<item>
<name>Chain Shirt</name>
<type>MA</type>
<magic />
<value>50gp</value>
<weight>20</weight>
<ac>13</ac>
<text>Made of interlocking metal rings, a chain shirt is worn between layers of clothing or leather. This armor offers modest protection to the wearer's upper body and allows the sound of the rings rubbing against one another to be muffled by outer layers.</text>
<text />
<text>Source: Player's Handbook, page 144</text>
</item>
<item>
<name>Chain Shirt +1</name>
<type>MA</type>
<magic>1</magic>
<weight>20</weight>
<ac>13</ac>
<rarity>Rare</rarity>
<text>Rarity: Rare</text>
<text>	You have a +1 bonus to AC while wearing this armor.</text>
<text />
<text>Source: Dungeon Master's Guide, page 152</text>
<modifier category="bonus">ac +1</modifier>
</item>

<item>
<name>Bead of Force</name>
<type>W</type>
<magic>1</magic>
<weight>0.0625</weight>
<rarity>Rare</rarity>
<text>Rarity: Rare</text>
<text>This small black sphere measures 3/4 of an inch in diameter and weighs an ounce. Typically, 1d4 + 4 beads of force are found together.</text>
<text>You can use an action to throw the bead up to 60 feet. The bead explodes on impact and is destroyed. Each creature within a 10-foot radius of where the bead landed must succeed on a DC 15 Dexterity saving throw or take 5d4 force damage. A sphere of transparent force then encloses the area for 1 minute. Any creature that failed the save and is completely within the area is trapped inside this sphere. Creatures that succeeded on the save, or are partially within the area, are pushed away from the center of the sphere until they are no longer inside it. Only breathable air can pass through the sphere's wall. No attack or other effect can.</text>
<text>An enclosed creature can use its action to push against the sphere's wall, moving the sphere up to half the creature's walking speed. The sphere can be picked up, and its magic causes it to weigh only 1 pound, regardless of the weight of creatures inside.</text>
<text />
<text>Source: Dungeon Master's Guide, page 154</text>
<roll>5d4</roll>
</item>


</compendium>
"""
    match result with
    | Ok res ->
        res |> Array.iter (printfn "%A")
        0
    | Error msg ->
        printfn "Error! %s" msg
        1
