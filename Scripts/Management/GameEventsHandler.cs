// The Game Events used across the Game.
// Anytime there is a need for a new event, it should be added here.

using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameEventsHandler
{
    public static readonly GameStartEvent GameStartEvent = new GameStartEvent();
    public static readonly GameOverEvent GameOverEvent = new GameOverEvent();
    public static readonly MoneyCollectEvent MoneyCollectEvent = new MoneyCollectEvent();
    public static readonly FinisherStartEvent FinisherStartEvent = new FinisherStartEvent();
    public static readonly PlayerFinishLevelEvent PlayerFinishLevelEvent = new PlayerFinishLevelEvent();
    public static readonly TutorialShowEvent TutorialShowEvent = new TutorialShowEvent();
    public static readonly TutorialToggleEvent TutorialToggleEvent = new TutorialToggleEvent();
    public static readonly AmbianceChangeEvent AmbianceChangeEvent = new AmbianceChangeEvent();
    public static readonly LevelCompleteEvent LevelCompleteEvent = new LevelCompleteEvent();
    public static readonly DebugCallEvent DebugCallEvent = new DebugCallEvent();
    public static readonly ItemInteractProgressUpdateEvent ItemInteractProgressUpdateEvent = new ItemInteractProgressUpdateEvent();
    public static readonly UseButtonClickEvent UseButtonClickEvent = new UseButtonClickEvent();
    public static readonly DefuseButtonClickEvent DefuseButtonClickEvent = new DefuseButtonClickEvent();
    public static readonly DrawingToggleEvent DrawingToggleEvent = new DrawingToggleEvent();
    public static readonly DrawingButtonClickEvent DrawingButtonClickEvent = new DrawingButtonClickEvent();
    public static readonly BombFoundEvent BombFoundEvent = new BombFoundEvent();
    public static readonly BombDefuseEvent BombDefuseEvent = new BombDefuseEvent();
    public static readonly BombActivateEvent BombActivateEvent = new BombActivateEvent();
    public static readonly LevelHintFoundEvent LevelHintFoundEvent = new LevelHintFoundEvent();
    public static readonly LevelObjectivesCompleteEvent LevelObjectivesCompleteEvent = new LevelObjectivesCompleteEvent();
}

public class GameEvent {}

public class GameStartEvent : GameEvent
{
}

public class GameOverEvent : GameEvent
{
    public bool IsWin;
}

public class MoneyCollectEvent : GameEvent
{
    
}

public class ItemInteractProgressUpdateEvent : GameEvent
{
    public float Progress;
    public Vector3 ScannerWorldPosition;
}
public class FinisherStartEvent : GameEvent
{
    
}

public class  PlayerFinishLevelEvent : GameEvent{}

public class TutorialShowEvent : GameEvent
{
}

public class TutorialToggleEvent : GameEvent
{
    public bool Toggle;
}


public class AmbianceChangeEvent : GameEvent
{
    public int Number;
}
public class LevelCompleteEvent : GameEvent
{
}
public class DebugCallEvent : GameEvent
{
    public float Speed;
    public float Strafe;
}

public class UseButtonClickEvent : GameEvent
{
    
}

public class DefuseButtonClickEvent : GameEvent
{
}

public class DrawingToggleEvent : GameEvent
{
    public bool Toggle;
    public bool IsFloor;
}

public class DrawingButtonClickEvent : GameEvent
{
    
}

public class BombFoundEvent : GameEvent
{
    public BombLevelObjectController BombObject;
}

public class BombDefuseEvent : GameEvent
{
    
}

public class BombActivateEvent : GameEvent
{
    public Transform BombTransform;
}

public class LevelHintFoundEvent : GameEvent
{
    public int NumberCompleted;
}

public class LevelObjectivesCompleteEvent : GameEvent
{
    public bool Toggle;
    public bool IsFirst;
}


