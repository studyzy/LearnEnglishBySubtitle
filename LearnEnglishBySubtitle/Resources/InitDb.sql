CREATE TABLE UserVocabulary ( 
    Id          INTEGER         PRIMARY KEY AUTOINCREMENT,
    Word        VARCHAR( 200 )  NOT NULL
                                UNIQUE,
    KnownStatus INT             NOT NULL,
    CreateTime  DATETIME        NOT NULL,
    UpdateTime  DATETIME        NOT NULL,
    Source      VARCHAR( 200 ),
    Sentence    VARCHAR( 500 ) 
);

CREATE TABLE IgnoreWord ( 
    Id         INTEGER         PRIMARY KEY AUTOINCREMENT,
    Word       VARCHAR( 200 )  UNIQUE,
    CreateTime DATETIME 
);

CREATE TABLE Subtitle_NewWord ( 
    Id           INTEGER         PRIMARY KEY AUTOINCREMENT,
    SubtitleName VARCHAR( 200 ),
    Sentence     VARCHAR( 500 ),
    Word         VARCHAR( 200 ),
    KnownStatus  INT,
    WordMean     TEXT,
    CreateTime   DATETIME 
);

CREATE UNIQUE INDEX idx_UserVocabulary ON UserVocabulary ( 
    KnownStatus,
    Word 
);

CREATE TABLE Config ( 
    ConfigKey   VARCHAR( 50 )   PRIMARY KEY,
    ConfigValue VARCHAR( 200 )  NOT NULL 
);

INSERT INTO Config VALUES('PronunciationType','US');
INSERT INTO Config VALUES('PronunciationDownload','False');