CREATE PROCEDURE Seed_ActionTypes
AS
BEGIN
	
	SET IDENTITY_INSERT ActionTypes ON

	MERGE INTO ActionTypes AS Target
	USING (VALUES
	  (1, 'Afspraken in agenda afzeggen', ''),
	  (2, 'Email sturen', ''),
	  (3, 'Telegram sturen', ''),
	  (4, 'Telefoon stil', ''),
	  (5, 'Hulpvraag uitzetten', ''),
	  (6, 'Out of Office instellen', ''),
	  (7, 'Eten bestellen', '')
	)
	AS Source (Id, Name, IconUri)
	ON Target.Id = Source.Id
	WHEN MATCHED THEN
		UPDATE SET	Name = Source.Name,
					IconUri = Source.IconUri
	WHEN NOT MATCHED THEN
		INSERT (Id, Name, IconUri)
		VALUES (Id, Name, IconUri);

		SET IDENTITY_INSERT ActionTypes OFF
END