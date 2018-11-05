using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;

public class MovementSystem : ComponentSystem {
	public struct Group{
		public readonly int indexer;
		public ComponentDataArray<Position> Positions;
	}
	public override void OnUpdate(){
		
	}
}
