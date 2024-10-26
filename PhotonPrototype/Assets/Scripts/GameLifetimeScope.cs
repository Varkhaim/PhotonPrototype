using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private Transform playerTransform;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(playerTransform);
        builder.Register<InputActions>(Lifetime.Singleton);
        builder.RegisterEntryPoint<PlayerController>();
        builder.Register<PlayerMovement>(Lifetime.Singleton)
               .WithParameter("movementSpeed", 5f)
               .WithParameter("playerTransform", playerTransform);
    }
}
