public class Boss1_Trigger : enemy_0_animationTrigger
{
    private Boss_1 boss_1 => GetComponentInParent<Boss_1>();

    private void Relocate() => boss_1.FIndPosition();

    private void MakeInvisisble() => boss_1.fx.MakeTransprent(true);
    private void MakeVisisble() => boss_1.fx.MakeTransprent(false);
}

