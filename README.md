# PlanetPrecedural

This is currently a work in progress, that I may revisit at a latter date.
The project was an expirement about doing large scale procedural generation, such as for a galaxy.
The main premise was to devide a large galaxy up into smaller quadrents, and then do procedural generation in those quadrents.
Basically, a main seed is used to generate per quadrent seeds, which are then saved. those seeds in turn are used to produce per system seed, and so on. the end goal was to allow for a large galaxy to be stored using a small amount of values.

The project is in unity, and where I left of was in programming the system of detecting which quadrent a player was in, and setting when to load the next quadrent using colliders.
Some of the code is from prior experiments, which were on getting precedural generation of solar systems. 
