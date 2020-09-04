# Unity Utilities

A collection of extension methods to make the work with vectors and colors more convenient.

## Code example
```c#
var vector = new Vector3(1, 1, 1);
// set Z
var withoutZ = vector.With(z: 0);
// deconstruction
var (x, y, z) = vector;
var (r, g, b) = Color.red;
```