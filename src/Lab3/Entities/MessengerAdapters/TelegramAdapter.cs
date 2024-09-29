using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.MessengerAdapters;

public class TelegramAdapter : IMessenger
{
    private readonly Telegram _telegram;

    public TelegramAdapter(Telegram telegram)
    {
        _telegram = telegram;
    }

    public void GetMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _telegram.GetMessage(message.Header + message.Body);
    }
}