CREATE TABLE "Label"
(
	"LabelId" INTEGER PRIMARY KEY,
	"Description" text NOT NULL,
	"DateCreated" datetime NOT NULL DEFAULT(strftime('%Y-%m-%d %H:%M:%S'))
);

CREATE TABLE "IncidentType"
(
	"IncidentTypeId" INTEGER PRIMARY KEY,
	"Label" text NOT NULL,
	"DateCreated" datetime NOT NULL DEFAULT(strftime('%Y-%m-%d %H:%M:%S'))
);

CREATE TABLE "IncidentTypeLabel"
(
	IncidentTypeLabelId INTEGER PRIMARY KEY,
	IncidentTypeId INTEGER NOT NULL,
	LabelId INTEGER NOT NULL,
	DateCreated datetime NOT NULL DEFAULT(strftime('%Y-%m-%d %H:%M:%S')),
	FOREIGN KEY ("IncidentTypeId") REFERENCES "IncidentType" ("IncidentTypeId"),
	FOREIGN KEY ("LabelId") REFERENCES "Label" ("LabelId")
);

CREATE TABLE "Incident"
(
	IncidentId INTEGER PRIMARY KEY,
	IncidentTypeId INTEGER NOT NULL,
	OrderId INTEGER NOT NULL,
	EmployeeId INTEGER NOT NULL,
	Resolution text,
	DateResolved datetime,
	Foreign Key("IncidentTypeId") REFERENCES "IncidentType" ("IncidentTypeId")
);
