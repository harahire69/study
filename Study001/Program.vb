Imports System
Imports System.IO



Module Program

    Sub InitData()
        Dim i_headers As New List(Of SampleHeader)
        Dim i_details As New List(Of SampleDetail)
        Dim i_items As New List(Of SampleItem)

        i_items.Add(New SampleItem With {.ItemId = 0, .ItemName = "�ς�����", .ItemPrice = "100", .ItemTypeCode = "ACT", .LastUpdate = Now})
        i_items.Add(New SampleItem With {.ItemId = 1, .ItemName = "�ǂ炭��", .ItemPrice = "400", .ItemTypeCode = "RPG", .LastUpdate = Now})
        i_items.Add(New SampleItem With {.ItemId = 2, .ItemName = "���ӂ���", .ItemPrice = "500", .ItemTypeCode = "RPG", .LastUpdate = Now})
        i_items.Add(New SampleItem With {.ItemId = 3, .ItemName = "�܂肨", .ItemPrice = "300", .ItemTypeCode = "ACT", .LastUpdate = Now})
        i_items.Add(New SampleItem With {.ItemId = 4, .ItemName = "���т���", .ItemPrice = "200", .ItemTypeCode = "STG", .LastUpdate = Now})

        i_headers.Add(New SampleHeader With {.HeaderId = 0, .HeaderName = "�Ԃ������", .LastUpdate = New Date(2017, 1, 1)})
        i_details.Add(New SampleDetail With {.DetailId = 0, .HeaderId = 0, .ItemId = 0, .Quantity = 1, .LastUpdate = Now})
        i_details.Add(New SampleDetail With {.DetailId = 1, .HeaderId = 3, .ItemId = 0, .Quantity = 1, .LastUpdate = Now})

        i_headers.Add(New SampleHeader With {.HeaderId = 1, .HeaderName = "�Ƃ񂪂�", .LastUpdate = New Date(2018, 2, 1)})
        i_details.Add(New SampleDetail With {.DetailId = 2, .HeaderId = 1, .ItemId = 0, .Quantity = 3, .LastUpdate = Now})
        i_details.Add(New SampleDetail With {.DetailId = 3, .HeaderId = 1, .ItemId = 1, .Quantity = 3, .LastUpdate = Now})
        i_details.Add(New SampleDetail With {.DetailId = 4, .HeaderId = 1, .ItemId = 2, .Quantity = 3, .LastUpdate = Now})
        i_details.Add(New SampleDetail With {.DetailId = 5, .HeaderId = 1, .ItemId = 3, .Quantity = 3, .LastUpdate = Now})
        i_details.Add(New SampleDetail With {.DetailId = 6, .HeaderId = 1, .ItemId = 4, .Quantity = 3, .LastUpdate = Now})

        i_headers.Add(New SampleHeader With {.HeaderId = 2, .HeaderName = "���Ă��", .LastUpdate = New Date(2018, 1, 1)})
        i_details.Add(New SampleDetail With {.DetailId = 7, .HeaderId = 2, .ItemId = 0, .Quantity = 1, .LastUpdate = Now})

        i_headers.Add(New SampleHeader With {.HeaderId = 3, .HeaderName = "�݂悿���", .LastUpdate = New Date(2018, 1, 1)})
        i_details.Add(New SampleDetail With {.DetailId = 8, .HeaderId = 3, .ItemId = 0, .Quantity = 1, .LastUpdate = Now})
        i_details.Add(New SampleDetail With {.DetailId = 9, .HeaderId = 3, .ItemId = 1, .Quantity = 1, .LastUpdate = Now})
        i_details.Add(New SampleDetail With {.DetailId = 10, .HeaderId = 3, .ItemId = 2, .Quantity = 1, .LastUpdate = Now})
        i_details.Add(New SampleDetail With {.DetailId = 11, .HeaderId = 3, .ItemId = 3, .Quantity = 1, .LastUpdate = Now})
        i_details.Add(New SampleDetail With {.DetailId = 12, .HeaderId = 3, .ItemId = 4, .Quantity = 1, .LastUpdate = Now})

        i_headers.Add(New SampleHeader With {.HeaderId = 4, .HeaderName = "���낷��", .LastUpdate = New Date(2018, 1, 1)})
    End Sub

    Sub Main(args As String())

        InitData()

        '�f�[�^�\�[�X�쐬
        Dim Names = {"����ƍN", "�D�c�M��", "����g�@", "�L�b�G�g", "����c��"}

        '�����_���Łu����v����n�܂���̂����𒊏o���鏈�����`
        Dim results = Names.Where(Function(name) name.StartsWith("����"))

        '�����_�������s���Č��ʂ�\��
        results.ToList.ForEach(Sub(name) Debug.WriteLine(name))


        Dim animals = {"�A�����{", "�C�m�V�V", "�E�}", "�G���}�L�g�J�Q", "�I�I�J�~"}
        Dim results2 = From animal In animals Where animal Like "*�}*"
        results2.ToList.ForEach(Sub(a) Debug.WriteLine(a))

        'Windows�t�H���_�[(�� C:\windows)�̃t�@�C���̈ꗗ
        Dim winFolder As New IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Windows))
        Dim fileList As IEnumerable(Of IO.FileInfo) = winFolder.EnumerateFiles

        '�t�@�C���̖��O�ƃT�C�Y�𒊏o
        Dim files = From file As IO.FileInfo In fileList
                    Select file.Name, file.Length

        'file �� Name�v���p�e�B �� Length �v���p�e�B�������������^�ł��B
        files.ToList.ForEach(Sub(file) Debug.WriteLine(file.Name & " " & file.Length.ToString))


        Dim filesX As IEnumerable(Of String) = Directory.EnumerateFiles("d:\", "*", SearchOption.AllDirectories)

        Dim enumerator As IEnumerator(Of String) = filesX.GetEnumerator()
        Dim success As Boolean = True

        Do While success
            Try
                success = enumerator.MoveNext()
                If success Then Console.WriteLine(enumerator.Current)
            Catch ex As UnauthorizedAccessException
                Console.WriteLine("Ignore")
                Continue Do
            End Try
        Loop

    End Sub

End Module
