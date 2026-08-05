## NPCShortcuts

Shows the Ctrl / Alt / Ctrl+Alt click shortcuts for NPCs when you hover them in the world.

<img width="366" height="258" alt="image" src="https://github.com/user-attachments/assets/0b5a9254-a929-4125-8a2c-39e8292030e1" />

Actions are read live from the game's NPC data (`NpcDat`), so every NPC is covered automatically. Verified per-version hotkeys (different locations/acts can have different shortcuts) live in `NPCHotkeys.cs`; vendors without a verified table still show the standard Sell/Buy hints. Sell renders red, Buy lime, other actions aqua — all configurable in settings.
