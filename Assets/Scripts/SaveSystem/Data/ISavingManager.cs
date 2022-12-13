using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISavingManager
{
     void Save(GameData gameData);
     void Load(GameData gameData);
}
