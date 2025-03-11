﻿using JewelryWeb.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; } = "Client";

    public Client Client { get; set; }
}