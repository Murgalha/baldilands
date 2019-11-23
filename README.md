# baldilands

## About
This game is a text-based RPG based on [3D&T](https://en.wikipedia.org/wiki/3D%26T),
a brazilian tabletop role-playing game.  

## Prerequisites
This project requires a C# compiler and you can use whichever you like,
but I recommend the [Mono project](https://www.mono-project.com/docs/about-mono/languages/csharp/) one, as it is open source.

### Install

#### Ubuntu
`# apt-get install mono-devel`

#### Arch
`# pacman -Syyu mono`

#### Gentoo
`# emerge --ask dev-lang/mono`

If your distro is not on the list, feel free to make a PR adding it here.

## Compiling
To compile this game, run `make` on the root folder of the project,
it will compile and generate a `baldilands` executable. 
Run the generated file on a terminal and Enjoy! :)  

**Note**: The Makefile uses the Mono compiler,
so you better install it before running `make`.  

If you want to use another compiler, or avoid using Makefile,
run your compiler of choice with every file inside the `Source` folder
and run the generated file on a terminal.
