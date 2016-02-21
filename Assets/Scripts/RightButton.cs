
public class RightButton : GameButton {

    protected override void DoMouseDown()
    {
        player.MoveRight();
    }

}
