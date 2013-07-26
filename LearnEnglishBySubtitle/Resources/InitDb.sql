CREATE TABLE UserVocabulary ( 
    Id          INTEGER         PRIMARY KEY AUTOINCREMENT,
    Word        VARCHAR( 200 )  NOT NULL    UNIQUE,
    KnownStatus INT             NOT NULL,
    CreateTime  DATETIME        NOT NULL,
    UpdateTime  DATETIME        NOT NULL,
    Source      VARCHAR( 50 ) 
);
CREATE TABLE Subtitle_KnownWord ( 
    Id      INTEGER         PRIMARY KEY AUTOINCREMENT,
    Word    VARCHAR( 200 )  NOT NULL,
    AddTime DATETIME        NOT NULL 
);
CREATE TABLE Subtitle_NewWord ( 
    Id           INTEGER         PRIMARY KEY AUTOINCREMENT,
    SubtitleName VARCHAR( 200 ),
    Sentence     VARCHAR( 500 ),
    Word         VARCHAR( 200 ),
    WordMean     TEXT 
);
CREATE UNIQUE INDEX idx_UserVocabulary ON UserVocabulary ( 
    KnownStatus,
    Word 
);
