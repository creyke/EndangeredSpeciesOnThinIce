# Endangered Species: On Thin Ice
Final year group project for the University Campus Suffolk (now University of Suffolk) BSc (Hons) Computer Games Programming course.

![Endangered Species: On Thin Ice](https://github.com/creyke/EndangeredSpeciesOnThinIce/raw/master/art/packaging/BoxArtVerySmall.jpg)

# Credits
* Roger Creyke - Code / Art
* George Daters - Code
* Ryan Avent - Art
* Dean Leeks - Project Management

![Endangered Species: On Thin Ice](https://github.com/creyke/EndangeredSpeciesOnThinIce/raw/master/art/marketing/ESOTI_DS_Shot_04_Small.png)

# Playing
## Playing on a Nintendo DS
1. You'll need a Nintendo DS.
2. You'll then need to purchase a Revolution R4 card or equivalent boot device on which to host the game binary.
3. Download and run one of the .nds binary file from the [builds](https://github.com/creyke/EndangeredSpeciesOnThinIce/tree/master/builds) folder.

## Playing on a Nintendo DS emulator
1. Download an emulator such as DeSmuME.
2. Download and run one of the .nds binary file from the [builds](https://github.com/creyke/EndangeredSpeciesOnThinIce/tree/master/builds) folder.

# Mapping
1. Run the editor from [source](https://github.com/creyke/EndangeredSpeciesOnThinIce/tree/master/editor/src) or (easier) from [binary](https://github.com/creyke/EndangeredSpeciesOnThinIce/tree/master/editor/bin) - the "Windows10" version has a setup.exe installer, after which EndangeredEd is in the start menu.
2. Download one of the [level](https://github.com/creyke/EndangeredSpeciesOnThinIce/tree/master/levels) files from this repository.
3. Open the map with "File / Open Level".

# Technology
* The game was written in C++ on top of PALib and libnds.
* All physics, camera and gameplay code was written from scratch.
* The primary render loop was handled by PALib.
* The editor was written in C#, using Winforms and XNA.
* Level files were composed in XML and exported to C++ to compile straight into the game.
