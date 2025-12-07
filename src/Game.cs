global using static Raylib_cs.Raylib;
global using Raylib_cs;
using System.Numerics;
using Raylib_cs;

namespace gravity;

public class Game
{
    private static Camera2D camera;
    public Game()
    {
        Scene scene = new Scene();

        camera = new Camera2D();
        camera.Offset = GetScreenCenter();
        camera.Target = Vector2.Zero;
        camera.Rotation = 0;
        camera.Zoom = 1f;
        
        InitWindow(1200, 800, "Space");
        SetTargetFPS(60);
        SetExitKey(KeyboardKey.Escape);
        
        while (!WindowShouldClose())
        {
            ClearBackground(Color.Black);
            
            scene.Update();
            BeginDrawing();
            BeginMode2D(camera);
            scene.render();
            EndMode2D();
            EndDrawing();
        }
    }
    
}