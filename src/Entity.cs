using System.Drawing;
using System.Numerics;
using Raylib_cs;
using Color = Raylib_cs.Color;

namespace gravity;

public class Entity
{
    public Vector2 position;
    public Vector2 velocity;
    public float mass;
    public int radius;

    public void update()
    {
        position += velocity;
    }

    public void render()
    {
        DrawCircleV(position, radius, Color.White);
    }
}