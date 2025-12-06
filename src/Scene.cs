using System.Data;
using System.Numerics;

namespace gravity;

public class Scene
{
    List<Entity> entities;
    
    public Scene()
    {
        entities = new List<Entity>();
        entities.Add(new Entity()
        {
            position = new Vector2(100,100),
            mass = 100000,
            radius = 30,
        });
        
        entities.Add(new Entity()
        {
            position = new Vector2(300,300),
            mass = 1000000,
            radius = 30,
        });
    }
    
    public void Update()
    {
        foreach (Entity affectingentity in entities)
        {
            foreach (Entity affectedentity in entities)
            {
                if (affectingentity == affectedentity) continue;
                float distance = Vector2.Distance(affectingentity.position, affectedentity.position);
                if (distance == 0) continue;
                float MassTimesMass = affectingentity.mass * affectedentity.mass;
                float GravConst = 0.000000001f;
                float DeltaVelocity = (GravConst * MassTimesMass) / (distance * distance);
                Vector2 PositionDiff = new Vector2(affectedentity.position.X - affectingentity.position.X, affectedentity.position.Y - affectingentity.position.Y);
                Vector2 DeltaVector = new Vector2((DeltaVelocity / MathF.Min(distance, 1)) * PositionDiff.X, (DeltaVelocity / MathF.Min(distance, 1)) * PositionDiff.Y);
                affectingentity.position += DeltaVector;
            }
        }
        
        {
            
        }
        foreach (Entity entity in entities) 
        {
            entity.update();
        }
    }
    // public void Update()
    // {
    //     // compute gravity
    //     for (int i = 0; i < entities.Count; i++)
    //     {
    //         for (int j = 0; j < entities.Count; j++)
    //         {
    //             if (i == j) continue;
    //
    //             Entity a = entities[i];
    //             Entity b = entities[j];
    //
    //             Vector2 diff = b.position - a.position;
    //             float dist = diff.Length();
    //
    //             if (dist < 0.001f) continue;
    //
    //             Vector2 dir = diff / dist;
    //
    //             float G = 1f; // <-- THIS is the magic fix
    //
    //             float forceMag = (G * a.mass * b.mass) / (dist * dist);
    //
    //             Vector2 force = dir * forceMag;
    //
    //             b.velocity -= force / b.mass;
    //         }
    //     }
    //
    //     // update positions
    //     foreach (Entity e in entities)
    //         e.update();
    // }


    public void render()
    {
        foreach (Entity entity in entities)
        {
            entity.render();
        }
    }
}