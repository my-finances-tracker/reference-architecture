CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240403194507_Transactions.InitialCreate') THEN
        IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'Transactions') THEN
            CREATE SCHEMA "Transactions";
        END IF;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240403194507_Transactions.InitialCreate') THEN
    CREATE TABLE "Transactions"."BankTransaction" (
        "Id" uuid NOT NULL,
        "Description" text NOT NULL,
        "Sender" text,
        "Receiver" text,
        "CreatedAt" timestamp with time zone NOT NULL,
        "CreatedById" text NOT NULL,
        "CreatedByName" text NOT NULL,
        "UpdatedAt" timestamp with time zone NOT NULL,
        "UpdatedById" text NOT NULL,
        "UpdatedByName" text NOT NULL,
        "Amount" double precision NOT NULL,
        "Source" text NOT NULL,
        "TransactionType" integer NOT NULL,
        CONSTRAINT "PK_BankTransaction" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240403194507_Transactions.InitialCreate') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20240403194507_Transactions.InitialCreate', '8.0.2');
    END IF;
END $EF$;
COMMIT;

