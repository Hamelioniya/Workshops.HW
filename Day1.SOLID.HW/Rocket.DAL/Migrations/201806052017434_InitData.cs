using System.IO;

namespace Rocket.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitData : DbMigration
    {
        public override void Up()
        {
            //��������� sql-������, ������� ����������������� ��������� ��� ������� album-info.ru
            var sqlFile = AppDomain.CurrentDomain.BaseDirectory + "/bin/Migrations/SQLQueries/InitAlbumInfoParserSettings.sql";
            Sql(File.ReadAllText(sqlFile));

            //��������� sql-������, ������� ����������������� ��������� ��� ������� lostfilm
            var sqlFileInitLostfilmParserSettings = AppDomain.CurrentDomain.BaseDirectory +
                                                    "/bin/Migrations/SQLQueries/InitLostfilmParserSettings.sql";
            Sql(File.ReadAllText(sqlFileInitLostfilmParserSettings));

            //��������� sql-������, ������� ����������������� ���� ������
            var sqlFileInitPersonTypes = AppDomain.CurrentDomain.BaseDirectory +
                                         "/bin/Migrations/SQLQueries/InitPersonTypes.sql";
            Sql(File.ReadAllText(sqlFileInitPersonTypes));

            //��������� sql-������, ������� ����������������� ���������
            var sqlFileInitCategory = AppDomain.CurrentDomain.BaseDirectory +
                                      "/bin/Migrations/SQLQueries/InitCategory.sql";
            Sql(File.ReadAllText(sqlFileInitCategory));

            var sqlFileEmail = AppDomain.CurrentDomain.BaseDirectory + "/bin/Migrations/SQLQueries/InitEmailTemplates.sql";
            Sql(File.ReadAllText(sqlFileEmail));

            //������������� �������� ������� �����������
            var sqlFileNotificationSettings = AppDomain.CurrentDomain.BaseDirectory + "/bin/Migrations/SQLQueries/InitNotificationsSettings.sql";
            Sql(File.ReadAllText(sqlFileNotificationSettings));
        }

        public override void Down()
        {
        }
    }
}
