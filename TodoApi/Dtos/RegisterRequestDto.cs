﻿namespace TodoApi.Dtos;

public class RegisterRequestDto
{
    public string? Name { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}
