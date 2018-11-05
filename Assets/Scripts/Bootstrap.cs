using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;


public class Bootstrap {

	public static EntityManager entiyManager;
	public static EntityArchetype playerEntityArchetype;

	[RuntimeInitializeOnLoadMethod(loadType: RuntimeInitializeLoadType.BeforeSceneLoad)]
	public static void Awake() {
		entiyManager = World.Active.GetOrCreateManager<EntityManager>();
		playerEntityArchetype = entiyManager.CreateArchetype(typeof(Position));
	}

	[RuntimeInitializeOnLoadMethod(loadType: RuntimeInitializeLoadType.AfterSceneLoad)]
	public static void Start() {
		GameObject playerGo = GameObject.Find("Player");
		MeshInstanceRenderer playerRenderer=  playerGo.GetComponent<MeshInstanceRendererComponent>().Value;
		Object.Destroy(playerGo);
		Entity player = entiyManager.CreateEntity(playerEntityArchetype);
		entiyManager.AddComponentData(player,new PlayerComponent());
		entiyManager.SetComponentData(player, new Position(){
			Value = new Unity.Mathematics.float3(0,2,0)
		});
		entiyManager.AddSharedComponentData(player,playerRenderer);
	}

}