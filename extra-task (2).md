# 🔧 Дополнительные методы для CRUD-приложения с Dapper

В этом документе представлены 10 полезных дополнительных методов, которые расширяют функциональность вашего CRUD-приложения на Dapper.

---

## 1. Получить всех студентов по имени ментора

```csharp
public IEnumerable<Student> GetStudentsByMentorNameAsync(string mentorName)
{
    // SQL-запрос для получения всех студентов, чей наставник имеет заданное имя
}
```

---

## 2. Получить группы по курсу

```csharp
public IEnumerable<Group> GetGroupsByCourseIdAsync(int courseId)
{
    // SQL-запрос для получения всех групп, связанных с заданным курсом
}
```

---

## 3. Проверить существование студента по Email

```csharp
public bool StudentExistsByEmailAsync(string email)
{
    // SQL-запрос для проверки существования студента с данным email
}
```

---

## 4. Обновить email студента

```csharp
public int UpdateStudentEmailAsync(int studentId, string newEmail)
{
    // SQL-запрос для обновления email студента по его Id
}
```

---

## 5. Удалить группу и ёё студентов

```csharp
public void DeleteGroupWithStudents(int groupId)
{
    // Метод удаляет всех студентов, относящихся к группе, а затем саму группу
}
```

---

## 6. Получить менторов, у которых есть студенты

```csharp
public List<Mentors> GetMentorsWithStudents()
{
    // Должен возвратить список менторов, у которых есть хотя бы один студент
}
```

---

## 7. Получить студентов без менторов

```csharp
public List<Student> GetStudentsWithoutMentors()
{
    // Вернёт список студентов, у которых MentorId = null
}
```

---

## 8. Получить количество студентов в каждой группе

```csharp
public List<GroupWithStudentCountDto> GetStudentCountByGroup()
{
    // Сделать GROUP BY по GroupId и вывести кол-во студентов в каждой группе
}
```

---

## 9. Получить курсы с нолевым числом групп

```csharp
public List<Course> GetCoursesWithoutGroups()
{
    // Вывести курсы, у которых нет ни одной группы
}
```

---

## 10. Удалить всех студентов по GroupId

```csharp
public int DeleteStudentsByGroup(int groupId)
{

}
```

---
