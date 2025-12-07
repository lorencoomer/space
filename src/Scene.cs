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
      position = new Vector2(350,350),
      mass = 50000,
      radius = 10,
      velocity = new Vector2(0.3f,-0.4f),
    });

    entities.Add(new Entity()
    {
      position = new Vector2(650,425),
      mass = 5000000,
      radius = 50,
    });

    entities.Add(new Entity()
    {
      position = new Vector2(200,150),
      mass = 75000,
      radius = 30,
    });
    
    Random random = new Random();
    
    for (int i = 0; i < 30; i++)
    {
      entities.Add(new Entity()
          {
            position = new Vector2(
              random.Next(100, 700),
              random.Next(100, 700)
            ),
            mass = 5000,
            radius = 2,
            velocity = new Vector2(
              (float)(random.NextDouble() * 0.1 - 0.05),
              (float)(random.NextDouble() * 0.1 - 0.05)
            ),
          });
    }
    
  }

  public void Update(float deltaTime = 1.0f)
  {
    foreach (Entity affectedentity in entities)
    {
      foreach (Entity affectingentity in entities)
      {
        if (affectingentity == affectedentity)
          continue;
  
        float distance = Vector2.Distance(
          affectingentity.position,
          affectedentity.position
        );
  
        if (distance == 0)
          continue;
  
        float minDistance = affectingentity.radius + affectedentity.radius;
  
        if (distance < minDistance)
          distance = minDistance;
  
        float GravConst = 1f;
        float force = (GravConst * affectingentity.mass) / (distance * distance);
  
        Vector2 direction = Vector2.Normalize(
          affectingentity.position - affectedentity.position
        );
  
        Vector2 acceleration = (direction * force) / affectedentity.mass;
  
        affectedentity.velocity += acceleration * deltaTime;
      }
    }
  
    foreach (Entity entity in entities)
    {
      entity.update();
    }

    if (IsMouseButtonPressed(MouseButton.Left))
    {
      entities.Add(new Entity()
      {
        position = new Vector2(GetMousePosition().X, GetMousePosition().Y),
        mass = 5000,
        radius = 2,
      });
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