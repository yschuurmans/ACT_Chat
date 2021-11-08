using ACT_Chat.Models.Chat;
using ACT_Chat.Models.Log;
using Advanced_Combat_Tracker;
using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ACT_ChatTests
{
    [TestClass]
    public class ChatParserTests
    {
        private readonly ChatParser sut = new ChatParser(Worlds.Odin);
        private Fixture _fixture;

        [TestInitialize]
        public void Setup()
        {
            _fixture = new Fixture();
        }

        [TestMethod]
        public void Parse_ValidInput_ParsesChatMessage()
        {
            //Arrange
            var inputString = "[00:27:08.000] 00:000d:▲John Doe:test test Message";
            var inputTime = DateTime.Now;

            //Act
            var result = sut.Parse(new LogInfo(inputString, inputTime));

            //Assert
            result.Target.RawName.Should().Be("▲John Doe");
            result.Target.Name.Should().Be("John Doe");
            result.Target.World.Should().Be(Worlds.Odin);
            result.Message.Should().Be("test test Message");
            result.TimeStamp.Should().Be(inputTime);
        }

        [TestMethod]
        public void Parse_DifferentWorld_ParsesChatMessage()
        {
            //Arrange
            var inputString = "[00:27:08.000] 00:000d:▲John DoeZodiark:test test Message :p";
            var inputTime = DateTime.Now;

            //Act
            var result = sut.Parse(new LogInfo(inputString, inputTime));

            //Assert
            result.Target.RawName.Should().Be("▲John DoeZodiark");
            result.Target.Name.Should().Be("John Doe");
            result.Target.World.Should().Be(Worlds.Zodiark);
            result.Message.Should().Be("test test Message :p");
            result.TimeStamp.Should().Be(inputTime);
        }

        [TestMethod]
        public void Parse_WithoutDateTime_ParsesChatMessage()
        {
            //Arrange
            var inputString = "[00:27:08.000] 00:000d:▲John DoeZodiark:test test Message :p";
            DateTime? inputTime = null;

            //Act
            var result = sut.Parse(new LogInfo(inputString, inputTime));

            //Assert
            result.Target.RawName.Should().Be("▲John DoeZodiark");
            result.Target.Name.Should().Be("John Doe");
            result.Target.World.Should().Be(Worlds.Zodiark);
            result.Message.Should().Be("test test Message :p");
            result.TimeStamp.Should().Be(DateTime.Parse("00:27:08.000"));
        }

        [TestMethod]
        public void Parse_AllDifferentWorlds_ParsesChatMessage()
        {
            foreach (Worlds world in Enum.GetValues(typeof(Worlds)))
            {
                //Arrange
                var message = _fixture.Create<string>();
                var inputString = $"[00:27:08.000] 00:000d:▲John Doe{world}:This is a testmessage! :D";
                var inputTime = DateTime.Now;

                //Act
                var result = sut.Parse(new LogInfo(inputString, inputTime));

                //Assert
                result.Target.RawName.Should().Be($"▲John Doe{world}");
                result.Target.Name.Should().Be("John Doe");
                result.Target.World.Should().Be(world);
                result.Message.Should().Be("This is a testmessage! :D");
                result.TimeStamp.Should().Be(inputTime);
            }
        }
    }
}
