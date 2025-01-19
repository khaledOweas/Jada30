namespace Identity.Domain.Entities.System;
public class SysConfig
{
    public long Id { get; set; }
    public required string Key { get; set; }
    public required string Value { get; set; }
}
