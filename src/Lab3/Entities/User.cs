using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class User
{
    private Dictionary<Message, MessageStatus> _messages = new();

    public User(string username)
    {
        Username = username;
    }

    public string Username { get; }

    public void MarkAsRead(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (_messages.TryGetValue(message, out MessageStatus value))
        {
            _messages[message] = value == MessageStatus.Unread
                ? MessageStatus.Read
                : throw new ReadMessageException("Message has already been read");
        }
        else
        {
            throw new ReadMessageException("Message doesn't exist");
        }
    }

    public void AcceptMessage(Message message)
    {
        _messages.Add(message, MessageStatus.Unread);
    }

    public MessageStatus GetMessageStatus(Message message)
    {
        if (_messages.TryGetValue(message, out MessageStatus status))
        {
            return status;
        }

        throw new ArgumentException("Message is not exist");
    }
}