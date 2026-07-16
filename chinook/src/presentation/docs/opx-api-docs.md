# Opx API Docs

Generated at: 2026-07-16 10:54:30 +07:00

## GET /api/albums

Controller: `Albums`
Action: `GetAlbums`

### Parameters

-

### Output

| StatusCode | Type |
| --- | --- |
| 200 | void |

## GET /api/albums/{id:int}

Controller: `Albums`
Action: `GetAlbum`

### Parameters

| Name | Source | Type | Required | Properties |
| --- | --- | --- | --- | --- |
| id | Path | Int32 | True | - |

### Output

| StatusCode | Type |
| --- | --- |
| 200 | void |

## GET /api/artists

Controller: `Artists`
Action: `GetArtists`

### Parameters

-

### Output

| StatusCode | Type |
| --- | --- |
| 200 | void |

## GET /api/artists/{id:int}

Controller: `Artists`
Action: `GetArtist`

### Parameters

| Name | Source | Type | Required | Properties |
| --- | --- | --- | --- | --- |
| id | Path | Int32 | True | - |

### Output

| StatusCode | Type |
| --- | --- |
| 200 | void |

## GET /api/artists/with-albums

Controller: `Artists`
Action: `GetArtistsWithAlbums`

### Parameters

-

### Output

| StatusCode | Type |
| --- | --- |
| 200 | void |

## GET /api/genres

Controller: `Genres`
Action: `GetGenres`

### Parameters

-

### Output

| StatusCode | Type |
| --- | --- |
| 200 | void |

## GET /api/genres/{id:int}

Controller: `Genres`
Action: `GetGenre`

### Parameters

| Name | Source | Type | Required | Properties |
| --- | --- | --- | --- | --- |
| id | Path | Int32 | True | - |

### Output

| StatusCode | Type |
| --- | --- |
| 200 | void |

## GET /opx/logs/access

Controller: `OpxLogs`
Action: `Access`

### Parameters

| Name | Source | Type | Required | Properties |
| --- | --- | --- | --- | --- |
| date | Query | String | False | - |
| take | Query | Int32 | True | - |

### Output

| StatusCode | Type |
| --- | --- |
| 200 | void |

## GET /opx/logs/security-issues

Controller: `OpxLogs`
Action: `SecurityIssues`

### Parameters

| Name | Source | Type | Required | Properties |
| --- | --- | --- | --- | --- |
| date | Query | String | False | - |
| take | Query | Int32 | True | - |

### Output

| StatusCode | Type |
| --- | --- |
| 200 | void |

## GET /opx/protection/health

Controller: `OpxProtection`
Action: `Health`

### Parameters

-

### Output

| StatusCode | Type |
| --- | --- |
| 200 | void |

## GET /opx/protection/metrics

Controller: `OpxProtection`
Action: `Metrics`

### Parameters

-

### Output

| StatusCode | Type |
| --- | --- |
| 200 | void |

