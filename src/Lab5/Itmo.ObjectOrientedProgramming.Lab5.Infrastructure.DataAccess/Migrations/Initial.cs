using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create type user_role as enum
        (
            'admin',
            'client'
            );
    create type operation_type as enum
        (
            'money_transfer',
            'money_receiving',
            'money_withdraw'
            );
    
    create type operation_result as enum
        (
            'success',
            'fail'
            );

    create table users(id serial, user_name varchar, password bigint, user_role user_role);

    insert into users(user_name, password, user_role) values('alyona', 505, 'client');


    create table bank_accounts(account_number bigint, user_name varchar, money_amount int);

    create table transaction_history(number serial,
                                     user_name varchar,
                                     account_number bigint,
                                     operation_type operation_type,
                                     operation_result operation_result,
                                     money_amount int);
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) => " ";
}