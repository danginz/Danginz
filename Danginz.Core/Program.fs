open Danginz.Core

[<EntryPoint>]
let main _argv =
    printfn "[Danginz.Core] Started!"
    let result = LionsDenParser.parseCompendiumXml """<?xml version='1.0' encoding='UTF-8'?>
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

<item>
<name>Pistol</name>
<type>R</type>
<weight>3 lbs</weight>
<dmg1>1d10</dmg1>
<dmgType>P</dmgType>
<property>A, LD</property>
<range>100/400</range>
<value>250g</value>
<text>Reload: 4</text>
<text>Misfire: 1</text>
<text />
<text>Reload: The weapon can be fired a number of times equal to its Reload number before the wielder must spend an Attack or an Action to reload. You must have one free hand to reload a firearm.</text>
<text />
<text>Misfire: Whenever you make an attack roll with a firearm, and the dice roll is equal or lower than the weapon’s misfire score, the weapon misfires. The attack misses, and the weapon cannot be used again until you spend an action to try and repair it. To repair your firearm, you must make a successful Tinker’s Tools check (DC equal to 8 + Misfire score).</text>
<text />
<text>Ammunition: You can use a weapon that has the ammunition property to make a ranged attack only if you have ammunition to fire from the weapon. Each time you attack with the weapon, you expend one piece of ammunition. Drawing the ammunition from a quiver, case, or other container is part of the attack. At the end of the battle, you can recover half your expended ammunition by taking a minute to search the battlefield.</text>
<text />
<text>If you use a weapon that has the ammunition property to make a melee attack, you treat the weapon as an improvised weapon.</text>
<text />
<text>Range: A weapon that can be used to make a ranged attack has a range shown in parentheses after the ammunition or thrown property. The range lists two numbers. The first is the weapon's normal range in feet, and the second indicates the weapon's maximum range. When attacking a target beyond normal range, you have disadvantage on the attack roll. You can't attack a target beyond the weapon's long range.</text>
<text />
</item>

<item>
<name>Pepperbox</name>
<type>R</type>
<weight>5 lbs</weight>
<dmg1>1d10</dmg1>
<dmgType>P</dmgType>
<property>A, LD</property>
<range>150/600</range>
<value>450g</value>
<text>Reload: 6</text>
<text>Misfire: 2</text>
<text />
<text>Reload: The weapon can be fired a number of times equal to its Reload number before the wielder must spend an Attack or an Action to reload. You must have one free hand to reload a firearm.</text>
<text />
<text>Misfire: Whenever you make an attack roll with a firearm, and the dice roll is equal or lower than the weapon’s misfire score, the weapon misfires. The attack misses, and the weapon cannot be used again until you spend an action to try and repair it. To repair your firearm, you must make a successful Tinker’s Tools check (DC equal to 8 + Misfire score).</text>
<text />
<text>Ammunition: You can use a weapon that has the ammunition property to make a ranged attack only if you have ammunition to fire from the weapon. Each time you attack with the weapon, you expend one piece of ammunition. Drawing the ammunition from a quiver, case, or other container is part of the attack. At the end of the battle, you can recover half your expended ammunition by taking a minute to search the battlefield.</text>
<text />
<text>If you use a weapon that has the ammunition property to make a melee attack, you treat the weapon as an improvised weapon.</text>
<text />
<text>Range: A weapon that can be used to make a ranged attack has a range shown in parentheses after the ammunition or thrown property. The range lists two numbers. The first is the weapon's normal range in feet, and the second indicates the weapon's maximum range. When attacking a target beyond normal range, you have disadvantage on the attack roll. You can't attack a target beyond the weapon's long range.</text>
<text />
</item>

<item>
<name>Musket</name>
<type>R</type>
<weight>10 lbs</weight>
<dmg1>1d12</dmg1>
<dmgType>P</dmgType>
<property>A, LD, 2H</property>
<range>200/800</range>
<value>500g</value>
<text>Reload: 1</text>
<text>Misfire: 2</text>
<text />
<text>Reload: The weapon can be fired a number of times equal to its Reload number before the wielder must spend an Attack or an Action to reload. You must have one free hand to reload a firearm.</text>
<text />
<text>Misfire: Whenever you make an attack roll with a firearm, and the dice roll is equal or lower than the weapon’s misfire score, the weapon misfires. The attack misses, and the weapon cannot be used again until you spend an action to try and repair it. To repair your firearm, you must make a successful Tinker’s Tools check (DC equal to 8 + Misfire score).</text>
<text />
<text>Ammunition: You can use a weapon that has the ammunition property to make a ranged attack only if you have ammunition to fire from the weapon. Each time you attack with the weapon, you expend one piece of ammunition. Drawing the ammunition from a quiver, case, or other container is part of the attack. At the end of the battle, you can recover half your expended ammunition by taking a minute to search the battlefield.</text>
<text />
<text>If you use a weapon that has the ammunition property to make a melee attack, you treat the weapon as an improvised weapon.</text>
<text />
<text>Range: A weapon that can be used to make a ranged attack has a range shown in parentheses after the ammunition or thrown property. The range lists two numbers. The first is the weapon's normal range in feet, and the second indicates the weapon's maximum range. When attacking a target beyond normal range, you have disadvantage on the attack roll. You can't attack a target beyond the weapon's long range.</text>
<text />
</item>

<item>
<name>Scattergun</name>
<type>R</type>
<weight>10 lbs</weight>
<dmg1>1d8</dmg1>
<dmgType>P</dmgType>
<property>A, LD</property>
<range>15/30</range>
<value>500g</value>
<text>Reload: 2</text>
<text>Misfire: 3</text>
<text>Scatter: yes</text>
<text />
<text>Reload: The weapon can be fired a number of times equal to its Reload number before the wielder must spend an Attack or an Action to reload. You must have one free hand to reload a firearm.</text>
<text />
<text>Misfire: Whenever you make an attack roll with a firearm, and the dice roll is equal or lower than the weapon’s misfire score, the weapon misfires. The attack misses, and the weapon cannot be used again until you spend an action to try and repair it. To repair your firearm, you must make a successful Tinker’s Tools check (DC equal to 8 + Misfire score).</text>
<text />
<text>Scatter: An attack is made on each creature within a 30ft cone. These attacks are simultaneous. If an affected creature is adjacent to you, they suffer double damage on a hit. This attack cannot be affected by any shot features.</text>
<text />
<text>Ammunition: You can use a weapon that has the ammunition property to make a ranged attack only if you have ammunition to fire from the weapon. Each time you attack with the weapon, you expend one piece of ammunition. Drawing the ammunition from a quiver, case, or other container is part of the attack. At the end of the battle, you can recover half your expended ammunition by taking a minute to search the battlefield.</text>
<text />
<text>If you use a weapon that has the ammunition property to make a melee attack, you treat the weapon as an improvised weapon.</text>
<text />
<text>Range: A weapon that can be used to make a ranged attack has a range shown in parentheses after the ammunition or thrown property. The range lists two numbers. The first is the weapon's normal range in feet, and the second indicates the weapon's maximum range. When attacking a target beyond normal range, you have disadvantage on the attack roll. You can't attack a target beyond the weapon's long range.</text>
<text />
</item>

<item>
<name>Bad News</name>
<type>R</type>
<weight>25 lbs</weight>
<dmg1>2d12</dmg1>
<dmgType>P</dmgType>
<property>A, LD, 2H</property>
<range>300/1200</range>
<value></value>
<text>Reload: 1</text>
<text>Misfire: 3</text>
<text />
<text>Reload: The weapon can be fired a number of times equal to its Reload number before the wielder must spend an Attack or an Action to reload. You must have one free hand to reload a firearm.</text>
<text />
<text>Misfire: Whenever you make an attack roll with a firearm, and the dice roll is equal or lower than the weapon’s misfire score, the weapon misfires. The attack misses, and the weapon cannot be used again until you spend an action to try and repair it. To repair your firearm, you must make a successful Tinker’s Tools check (DC equal to 8 + Misfire score).</text>
<text />
<text>Ammunition: You can use a weapon that has the ammunition property to make a ranged attack only if you have ammunition to fire from the weapon. Each time you attack with the weapon, you expend one piece of ammunition. Drawing the ammunition from a quiver, case, or other container is part of the attack. At the end of the battle, you can recover half your expended ammunition by taking a minute to search the battlefield.</text>
<text />
<text>If you use a weapon that has the ammunition property to make a melee attack, you treat the weapon as an improvised weapon.</text>
<text />
<text>Range: A weapon that can be used to make a ranged attack has a range shown in parentheses after the ammunition or thrown property. The range lists two numbers. The first is the weapon's normal range in feet, and the second indicates the weapon's maximum range. When attacking a target beyond normal range, you have disadvantage on the attack roll. You can't attack a target beyond the weapon's long range.</text>
<text />
</item>

<item>
<name>Hand Mortar</name>
<type>R</type>
<weight>10 lbs</weight>
<dmg1>2d8</dmg1>
<dmgType>F</dmgType>
<property>A, LD</property>
<range>100/400</range>
<value></value>
<text>Reload: 1</text>
<text>Misfire: 3</text>
<text>Explosive: yes</text>
<text />
<text>Reload: The weapon can be fired a number of times equal to its Reload number before the wielder must spend an Attack or an Action to reload. You must have one free hand to reload a firearm.</text>
<text />
<text>Misfire: Whenever you make an attack roll with a firearm, and the dice roll is equal or lower than the weapon’s misfire score, the weapon misfires. The attack misses, and the weapon cannot be used again until you spend an action to try and repair it. To repair your firearm, you must make a successful Tinker’s Tools check (DC equal to 8 + Misfire score).</text>
<text />
<text>Explosive: Upon a hit, everything within 5 ft of the target must make a Dexterity saving throw (DC equal to 8 + your proficiency bonus + your Dexterity modifier) or suffer 1d8 fire damage. If the weapon misses, the ammunition fails to detonate, or bounces away harmlessly before doing so.</text>
<text />
<text>Ammunition: You can use a weapon that has the ammunition property to make a ranged attack only if you have ammunition to fire from the weapon. Each time you attack with the weapon, you expend one piece of ammunition. Drawing the ammunition from a quiver, case, or other container is part of the attack. At the end of the battle, you can recover half your expended ammunition by taking a minute to search the battlefield.</text>
<text />
<text>If you use a weapon that has the ammunition property to make a melee attack, you treat the weapon as an improvised weapon.</text>
<text />
<text>Range: A weapon that can be used to make a ranged attack has a range shown in parentheses after the ammunition or thrown property. The range lists two numbers. The first is the weapon's normal range in feet, and the second indicates the weapon's maximum range. When attacking a target beyond normal range, you have disadvantage on the attack roll. You can't attack a target beyond the weapon's long range.</text>
<text />
</item>

<class>
<name>Fighter (Gunslinger)</name>
<autolevel level="3">
<feature optional="YES">
<name>Gunslinger: Firearm Proficiency</name>
<text>Gunslingers gain proficiency with Firearms, thus able to add their proficiency bonus to Firearm attacks.</text>
</feature>
<feature optional="YES">
<name>Gunslinger: Grit</name>
<text>At the end of each Short Rest, a Gunslinger gains a number of Grit points equal to their Wisdom Modifier (minimum 1). The number of Grit points the Gunslinger has can never exceed their Wisdom modifier. The Gunslinger can regain Grit points in the following ways:</text>
<text>Critical Hit with a Firearm:</text>
<text>Each time the Gunslinger scores a Critical Hit with a Firearm attack while in the heat of combat, they regain 1 Grit point.</text>
<text>Killing Blow with a Firearm:</text>
<text>When the Gunslinger reduces a creature to 0 or fewer hit points with a Firearm attack, they regain 1 Grit point. If the death was due to a Critical Hit, you only get the 1 Grit, not two.</text>
</feature>
<feature optional="YES">
<name>Gunslinger: Deeds</name>
<text>Gunslingers use Grit points to perform Deeds. Some deeds are instant bonuses or attacks, while others are bonuses that can last for a period of time. Some deeds last as long as the Gunslinger has 1 Grit Point. A Gunslinger can only use Deeds that they meet the required level for, and cannot combine multiple Deeds into a single attack.</text>
<text>Gunsmith:</text>
<text>Starting at 3rd level, the Gunslinger gains proficiency with Tinker’s Tools, able to use them to craft ammunition, repair damaged firearms, or even draft and create them.</text>
<text>Deadeye:</text>
<text>Starting at 3rd level, the Gunslinger can spend 1 Grit point to gain Advantage on the next Attack roll they make this round. The Gunslinger chooses to make a Deadeye attack and spends Grit before making the attack roll.</text>
</feature>
<feature optional="YES">
<name>Gunslinger: Firearm Properties</name>
<text>Reload</text>
<text>The weapon can be fired a number of times equal to its Reload number before the wielder must spend 1 Attack of your Attack Action, or an Action, to reload. You must have one free hand to reload a firearm. </text>
<text>Misfire</text>
<text>Whenever the Firearm is fired in a way that requires an Attack Roll, if the dice roll is equal to or lower than the Misfire number, the weapon Misfires, the attack misses, and it cannot be used to attack again until an Action and successful Tinker’s Tools Ability Check (DC = 10 + Firearm’s Misfire Score) is used to repair and clear the weapon. Should the Tinker’s Tools check fail, the weapon is considered broken and must be repaired out of combat at half the cost of the weapon (or DM’s discretion).</text>
<text>Scatter</text>
<text>An attack is made against each creature within a 30 ft cone. If an affected creature is adjacent to you, they suffer double damage on a hit.</text>
<text>Explosive</text>
<text>Upon a hit, everything within 5 ft of the target must make a Dexterity saving throw or suffer half damage. If the weapon misses, the ammunition fails to detonate, or bounces away harmlessly before doing so.</text>
</feature>
</autolevel>
<autolevel level="7">
<feature optional="YES">
<name>Gunslinger: Aditional Deeds</name>
<text>Quick Draw:</text>
<text>Starting at 7th level, the Gunslinger gains +2 Initiative and can draw and stow Firearms as a free Flourish.</text>
<text>Violent Shot:</text>
<text>Starting at 7th Level, the Gunslinger can spend 1 or more Grit points before rolling an Attack. For each Grit point spent, that Attack gains +1 to the weapon’s Misfire number. If the attack hits, it deals an additional dice of Firearm damage per Grit point spent. If the attack misses, Grit points are still expended. (ex: 3 Grit points = +3 to misfire, +3d[Firearm Damage Die]). Weapons with multiple damage dice add only 1 die per Grit spent. (ex: a 2d12 gun adds +1d12 per Grit)</text>
</feature>
</autolevel>
<autolevel level="10">
<feature optional="YES">
<name>Gunslinger: Aditional Deed - Trick Shot</name>
<text>Starting at 10th Level, the Gunslinger can spend a Grit point to target a specific location on a foe’s body with a Firearm. If the attack misses, the Grit point is still lost. If the Gunslinger has multiple attacks for their Attack action, they can make multiple Targeted shots for 1 Grit point each. Your Trick Shot DC is 8 + your Proficiency Mod + your Dexterity Mod.</text>
<text>• Arms – On a hit, the target takes normal damage and must make a Strength saving throw or drop 1 held item of the Gunslinger’s choice.</text>
<text>• Head – On a hit, the target takes normal damage and must make a Constitution saving throw or have disadvantage on attacks for 1 round.</text>
<text>• Legs – On a hit, the target takes normal damage and must make a Strength saving throw or get knocked prone.</text>
<text>• Torso – On a hit, the target takes normal damage and is pushed up to 10 ft away from you.</text>
<text>• Wings – On a hit, the target takes normal damage, and must make a Constitution saving throw or plummet 20 ft.</text>
</feature>
</autolevel>
<autolevel level="15">
<feature optional="YES">
<name>Gunslinger: Aditional Deed - Lightning Reload</name>
<text>Starting at 15th level, the Gunslinger can reload a one-handed or two-handed firearm as a Bonus action.</text>
</feature>
</autolevel>
<autolevel level="18">
<feature optional="YES">
<name>Gunslinger Aditional Deeds</name>
<text>Cheat Death:</text>
<text>Starting at 18th level, whenever the Gunslinger is reduced to 0 hit points or lower, the Gunslinger can immediately spend all of their current Grit points (minimum of 1) to instead be reduced to 1 hit point.</text>
<text>Mortal Shot:</text>
<text>Starting at 18th level, whenever the Gunslinger scores a Critical Hit with a firearm (even with another Deed), they can spend a Grit point to increase the damage multiplier for that attack from x 2 to x 3.</text>
</feature>
</autolevel>
</class>

</compendium>
"""
    match result with
    | Ok res ->
        printfn "%A" res
        0
    | Error msg ->
        printfn "Error! %s" msg
        1
