using System;

public interface IAttaker {
    // �U���͈͂ɐG�ꂽ���̏�����o�^
    void AddAttack(Action dam);
    
    void DeleteAttack(Action dam);
}
