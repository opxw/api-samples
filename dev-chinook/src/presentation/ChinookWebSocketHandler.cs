// Copyright (c) 2026 - opx
using System.Text;
using Opx.Api.Web.WebSockets;

public sealed class ChinookWebSocketHandler : OpxWebSocketHandler
{
	public override ValueTask OnConnectedAsync(OpxWebSocketSession session, CancellationToken cancellationToken)
	{
		return new ValueTask(session.SendJsonAsync(new
		{
			type = "connected",
			sessionId = session.Id
		}, cancellationToken));
	}

	public override ValueTask OnTextMessageAsync(OpxWebSocketSession session, ReadOnlyMemory<byte> utf8Message, CancellationToken cancellationToken)
	{
		return new ValueTask(session.SendJsonAsync(new
		{
			type = "chinook.echo",
			message = Encoding.UTF8.GetString(utf8Message.Span)
		}, cancellationToken));
	}
}

public sealed record ArtistWatchRequest(int ArtistId);

public sealed class ArtistWatchMessageHandler : OpxWebSocketMessageHandler<ArtistWatchRequest>
{
	public override string Type => "artist.watch";

	protected override ValueTask HandleAsync(
		OpxWebSocketSession session,
		ArtistWatchRequest? data,
		OpxWebSocketMessage message,
		CancellationToken cancellationToken)
	{
		return new ValueTask(session.SendMessageAsync(
			"artist.watching",
			new { artistId = data?.ArtistId },
			correlationId: message.MessageId,
			cancellationToken: cancellationToken));
	}
}
