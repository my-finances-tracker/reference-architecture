CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240222211233_Transactions.InitialCreate') THEN
        IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'Transactions') THEN
            CREATE SCHEMA "Transactions";
        END IF;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240222211233_Transactions.InitialCreate') THEN
    CREATE TABLE "Transactions"."Transaction" (
        "Id" uuid NOT NULL,
        "Amount" double precision NOT NULL,
        "Source" text NOT NULL,
        "TransactionType" integer NOT NULL,
        "Discriminator" character varying(21) NOT NULL,
        "Description" text,
        "Sender" text,
        "Receiver" text,
        CONSTRAINT "PK_Transaction" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240222211233_Transactions.InitialCreate') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20240222211233_Transactions.InitialCreate', '8.0.2');
    END IF;
END $EF$;
COMMIT;

