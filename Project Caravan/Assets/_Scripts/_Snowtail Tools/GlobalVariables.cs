using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables {
    //Player characters global Variable
    public static string PLAYER_TAG = "Player";
    public static int PLAYER_LAYER = LayerMask.NameToLayer("Player");

    //Enemies global variables
    public static int ENEMY_LAYER = LayerMask.NameToLayer("Enemy");
    public static string ENEMY_TAG = "Enemy";

    //Drop Area variables
    public static int DROP_AREA_LAYER = LayerMask.NameToLayer("Drop");
    public static string DROP_AREA_TAG = "Drop";

    //Utilities
    public static float FADING_SPEED = 7.0f;
    public static string INTERACTABLE_TAG = "Interactable";
    public static int INTERACTABLE_LAYER = LayerMask.NameToLayer("Interactable");
    public static int INSPECTABLE_LAYER = LayerMask.NameToLayer("Inpsectable");
    public static int IGNORE_VISION_LAYER = LayerMask.NameToLayer("IgnoreVision");
    public static int IGNORE_RAYCAST_LAYER = LayerMask.NameToLayer("IgnoreRaycast");
    public static int CAMERA_HIDE_LAYER = LayerMask.NameToLayer("CameraHide");
    public static int ROOM_LAYER = LayerMask.NameToLayer("Room");
    public static int MOVEABLE_LAYER = LayerMask.NameToLayer("Moveable");
    public static int LEVER_LAYER = LayerMask.NameToLayer("Lever");

    //Folder Access
    public static string RUNTIMESETS_PATH = "RuntimeSets/";
    public static string TOOL_EVENTS_PATH = "ToolsEvents/";
    public static string LOCALIZATION_PATH = "Localization/";

    //RuntimeSet Path;
    public static string CHARACTER_RUNTIMESET_PATH = RUNTIMESETS_PATH + "CharactersSet";
}
