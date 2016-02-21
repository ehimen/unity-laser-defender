
public class LeftButton : GameButton {

    protected override void DoMouseDown()
    {
        player.MoveLeft();
    }

}
