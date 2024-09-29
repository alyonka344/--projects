using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.MessengerAdapters;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;
using NSubstitute;
using Xunit;
using static Itmo.ObjectOrientedProgramming.Lab3.Models.ImportanceLevel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Tests
{
    [Fact]
    public void UserGetMessage_MessageIsUnread()
    {
        // arrange
        var user = new User("alyonka344");
        var topic = new Topic("topic", new AddresseeUser(user, "alyonka344"));
        var message = new Message("message", "priv, alyonka344", High);

        // act
        topic.SendMessage(message);

        // assert
        Assert.Equal(MessageStatus.Unread, user.GetMessageStatus(message));
    }

    [Fact]
    public void MarkUnreadMessageAsRead_MessageIsRead()
    {
        // arrange
        var user = new User("alyonka344");
        var topic = new Topic("topic", new AddresseeUser(user, "alyonka344"));
        var message = new Message("message", "priv, alyonka344", High);

        // act
        topic.SendMessage(message);
        user.MarkAsRead(message);

        // assert
        Assert.Equal(MessageStatus.Read, user.GetMessageStatus(message));
    }

    [Fact]
    public void MarkReadMessageAsRead_ThrowException()
    {
        // arrange
        var user = new User("alyonka344");
        var topic = new Topic("topic", new AddresseeUser(user, "alyonka344"));
        var message = new Message("message", "priv, alyonka344", High);

        // act
        topic.SendMessage(message);
        user.MarkAsRead(message);

        // assert
        Assert.Throws<ReadMessageException>(() => user.MarkAsRead(message));
    }

    [Fact]
    public void MessageWithLowImportanceLevelSendToUserWithFilterMiddleImportanceLevel_MessageDidntReceive()
    {
        // arrange
        IAddressee addressee = Substitute.For<IAddressee>();
        IAddressee addresseeWithFilter = new AddresseeFilter(addressee, ImportanceLevel.Middle, "alyonka344");
        var topic = new Topic("topic", addresseeWithFilter);
        var message = new Message("message", "i want to relax", Low);

        // act
        topic.SendMessage(message);

        // assert
        addressee.DidNotReceive().GetMessage(message);
    }

    [Fact]
    public void LoggerAddressee_FunctionLogIsWorking()
    {
        // arrange
        ILogger logger = Substitute.For<ILogger>();
        var addressee = new AddresseeUser(new User("alyonka344"), "alyonka344");
        var addresseeWithLogger =
            new AddresseeLogger(
                addressee,
                "alyonka344",
                logger);
        var topic = new Topic("topic", addresseeWithLogger);
        var message = new Message("message", "i want to relax", Low);

        // act
        topic.SendMessage(message);

        // assert
        logger.Received().Log(addressee, message);
    }

    [Fact]
    public void SendMessageToMessenger_MessengerIsWorking()
    {
        // arrange
        IMessenger messenger = Substitute.For<IMessenger>();
        var addressee = new AddresseeMessenger(messenger, "alyonka344");
        var topic = new Topic("topic", addressee);
        var message = new Message("message", "i want to relax", Low);

        // act
        topic.SendMessage(message);

        // assert
        messenger.Received().GetMessage(message);
    }
}