CREATE TABLE "Customer"
(
	"CustomerId" INTEGER PRIMARY KEY,
	"FirstName" text NOT NULL,
	"LastName" text NOT NULL,
	"DateCreated" datetime NOT NULL DEFAULT(strftime('%Y-%m-%d %H:%M:%S'))
);

CREATE TABLE "Department"
(
	"DepartmentId" INTEGER PRIMARY KEY,
	"Label" text NOT NULL,
	"DateCreated" datetime NOT NULL DEFAULT(strftime('%Y-%m-%d %H:%M:%S'))
);

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

CREATE TABLE "Order"
(
	OrderId INTEGER PRIMARY KEY,
	Date datetime NOT NULL,
	CustomerId INTEGER NOT NULL,
	DateCreated datetime NOT NULL DEFAULT(strftime('%Y-%m-%d %H:%M:%S')),
	FOREIGN KEY ("CustomerId") REFERENCES "Customer" ("CustomerId")
);

CREATE TABLE "Employee"
(
	EmployeeId INTEGER PRIMARY KEY,
	FirstName text NOT NULL,
	LastName text NOT NULL,
	DepartmentId INTEGER NOT NULL,
	Administrator bool NOT NULL,
	DateCreated datetime NOT NULL DEFAULT(strftime('%Y-%m-%d %H:%M:%S')),
	FOREIGN KEY ("DepartmentId") REFERENCES "Department" ("DepartmentId")
);

CREATE TABLE "Incident"
(
	IncidentId INTEGER PRIMARY KEY,
	IncidentTypeId INTEGER NOT NULL,
	OrderId INTEGER NOT NULL,
	EmployeeId INTEGER NOT NULL,
	Resolution text,
	DateResolved datetime,
	FOREIGN KEY ("IncidentTypeId") REFERENCES "IncidentType" ("IncidentTypeId"),
	FOREIGN KEY ("OrderId") REFERENCES "Order" ("OrderId"),
	FOREIGN KEY ("EmployeeId") REFERENCES "Employee" ("EmployeeId")
);