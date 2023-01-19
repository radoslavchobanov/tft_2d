public enum EventID
{
    // Mouse Input Events
    MouseLeftClicked,
    MouseRightClicked,

    // Unit events
    UnitRightClicked,

    // Ally units events
    AllyUnitLeftClicked,
    AllyUnitSelected,
    AllyUnitPlaced,
    AllyUnitBought,
    AllyUnitInstantiated,
    AllyUnitSpawned,

    // Tile Events
    AllyTileClicked,

    // Store events
    StoreRefreshed,
    XPBought,

    // Round Events
    BuyRoundStart,
    FightRoundStart,

    // UI Events
    ChangeGameStateButtonClicked,
}