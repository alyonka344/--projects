namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.AddresseeGroup;

public interface IAddresseeGroupBuilder
{
    public void AddUser(User user);
    public AddresseeGroup Build();
}