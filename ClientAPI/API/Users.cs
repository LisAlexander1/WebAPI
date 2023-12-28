namespace ClientAPI.API;

public static class Users
{
    private const string Base = "/users/";
    public static string Auth => $"{Base}/auth";
}