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

        entities.Add(new Entity()
        {
            position = new Vector2(400,150),
            mass = 2000000,
            radius = 40,
        });
    }
    
    public void Update()
    {
        foreach (Entity affectingentity in entities)
        {
            foreach (Entity affectedentity in entities)
            {
                if (affectingentity == affectedentity)
                {
                    continue;
                }
                
                float distance = Vector2.Distance(affectingentity.position, affectedentity.position);
                if (distance == 0)
                    
                {
                    continue;
                }
                
                float MassTimesMass = affectingentity.mass * affectedentity.mass;
                float GravConst = 0.0000000000001f;
                float DeltaVelocity = (GravConst * MassTimesMass) / (distance * distance);
                Vector2 PositionDiff = new Vector2(affectedentity.position.X - affectingentity.position.X, affectedentity.position.Y - affectingentity.position.Y);
                Vector2 DeltaVector = new Vector2((DeltaVelocity / MathF.Min(distance, 1)) * PositionDiff.X, (DeltaVelocity / MathF.Min(distance, 1)) * PositionDiff.Y);

                affectingentity.velocity += DeltaVector;
            }
        }
        
        {
            
        }
        foreach (Entity entity in entities) 
        {
            entity.update();
        }
    }   

    public void render()
    {
        foreach (Entity entity in entities)
        {
            entity.render();
        }
    }
}