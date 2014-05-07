Dibware.EF.Extensions
=====================

Inspired by GenericExtensionsEFCF (https://github.com/LucBos/GenericExtensionsEFCF) created by LucBos I am endeavouring to develop my own extensions for Entity Framework to cover some of my own specific needs.


## This is very much A WORK IN PROGRESS!!!

## Prerequisite Assemblies
* EntityFramework.SqlServer.dll
* EntityFramework.dll
* Dibware.Extensions.dll

## Contracts
* IStoredProcedure

### IStoredProcedure
#### Members
* String FullName { get; }
* String Name { get; }
* String Schema { get; }
* IEnumerable<SqlParameter> Parameters { get; }

## Classes
* DatabaseExtensions
* CommandHelper
* ParameterHelper

### DatabaseExtensions
#### Members
* IEnumerable<TResult> ExecuteStoredProcedure<TResult>(
            this Database database,
            IStoredProcedure<TResult> procedure) where TResult : class
* T ExecuteScalarCommandText<T>(
            this Database database,
            String commandText)
* T ExecuteScalarStoredProcedure<T>(
            this Database database,
            IStoredProcedure<T> procedure)

### CommandHelper
#### Members
* static String CreateStoredProcedureCommandString<TResult>(
            String storedProcedureName,
            IEnumerable<SqlParameter> parameters)

### CommandHelper
#### ParameterHelper
* public static IEnumerable<SqlParameter> BuildParametersFromDictionary(
            IDictionary<String, Object> paramters)
* public static SqlParameter ConvertKeyValuePairToSqlParameter(
            KeyValuePair<String, Object> parameter)
