
public class FireButton : GameButton {

    protected override void DoMouseDown()
    {
        player.Fire();
    }

}
