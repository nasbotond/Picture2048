IF object_id('scoreboard_items', 'U') is not null DROP TABLE scoreboard_items;

CREATE TABLE scoreboard_items (
	sbItem_id int primary key, -- first field is almost always an id primary key
	sbItem_playerName nvarchar(100), -- always use nvarchar(N) because you might use non english characters, also size of N isn't a problem unless you have more than 200 fields
	sbItem_score int,
	sbItem_time time
);