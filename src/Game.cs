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
        camera.Zoom = 0.5f;
        
        InitWindow(800, 600, "Space");
        SetTargetFPS(60);
        SetExitKey(KeyboardKey.Escape);
        
        InitAudioDevice();
        Sound resonance = LoadSound("assets/resonance.wav");
        bool played = false;
        
        while (!WindowShouldClose())
        {
            if (!played)
            {
                PlaySound(resonance);
                played = true;
            }
            ClearBackground(Color.Black);
            
            scene.Update();
            BeginDrawing();
            BeginMode2D(camera);
            scene.render();
            EndMode2D();
            EndDrawing();
        }
        
        UnloadSound(resonance);
        CloseAudioDevice();
        CloseWindow();
    }
    
}