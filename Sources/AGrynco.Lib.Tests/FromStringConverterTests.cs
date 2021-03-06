﻿#region Usings
using System;
using AGrynCo.Lib.StrUtils.FromStringConverters;
using NUnit.Framework;
#endregion

namespace AGrynco.Lib.Tests
{
    [TestFixture]
    public class FromStringConverterTests
    {
        [Test]
        public void ConvertFromBool_False()
        {
            // Act
            bool actual = FromStringConverter.Convert<bool>("FaLse");

            //Asserts
            Assert.That(actual, Is.EqualTo(false));
        }

        [Test]
        public void ConvertFromBool_True()
        {
            // Act
            bool actual = FromStringConverter.Convert<bool>("TrUe");

            //Asserts
            Assert.That(actual, Is.EqualTo(true));
        }

        [Test]
        public void ConvertToTimeSpan()
        {
            //Act
            TimeSpan actual = FromStringConverter.Convert<TimeSpan>("9:0:0");

            //Asserts
            Assert.That(actual, Is.EqualTo(new TimeSpan(9, 0, 0)));
        }
    }
}