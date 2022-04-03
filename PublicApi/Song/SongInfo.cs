﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using static ArcaeaUnlimitedAPI.PublicApi.Response;

namespace ArcaeaUnlimitedAPI.PublicApi;

public partial class PublicApi
{
    [HttpGet("/botarcapi/song/info")]
    public object GetSongInfo(string? songname, string? songid)
    {
        if (!UserAgentCheck()) return NotFound(null);

        var song = QuerySongInfo(songname, songid, out var songerror);

        if (song is null) return songerror ?? Error.InvalidSongNameorID;

        return Success(song.ToJson());
    }
    
    [EnableCors]
    [HttpGet("/botarcapi/test/song/info")]
    public object GetSongInfoExperimental(string? songname, string? songid)
    {
        if (!UserAgentCheck()) return NotFound(null);

        var song = QuerySongInfoExperimental(songname, songid, out var songerror);

        if (song is null) return songerror ?? Error.InvalidSongNameorID;

        return Success(song.ToJson());
    }
}
