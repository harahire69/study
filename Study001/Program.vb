Imports System
Imports System.IO



Module Program

    Sub InitData()
        Dim i_headers As New List(Of SampleHeader)
        Dim i_details As New List(Of SampleDetail)
        Dim i_items As New List(Of SampleItem)

        i_items.Add(New SampleItem With {.ItemId = 0, .ItemName = "ぱっくら", .ItemPrice = "100", .ItemTypeCode = "ACT", .LastUpdate = Now})
        i_items.Add(New SampleItem With {.ItemId = 1, .ItemName = "どらくえ", .ItemPrice = "400", .ItemTypeCode = "RPG", .LastUpdate = Now})
        i_items.Add(New SampleItem With {.ItemId = 2, .ItemName = "えふえふ", .ItemPrice = "500", .ItemTypeCode = "RPG", .LastUpdate = Now})
        i_items.Add(New SampleItem With {.ItemId = 3, .ItemName = "まりお", .ItemPrice = "300", .ItemTypeCode = "ACT", .LastUpdate = Now})
        i_items.Add(New SampleItem With {.ItemId = 4, .ItemName = "ぜびうす", .ItemPrice = "200", .ItemTypeCode = "STG", .LastUpdate = Now})

        i_headers.Add(New SampleHeader With {.HeaderId = 0, .HeaderName = "ぶたごりら", .LastUpdate = New Date(2017, 1, 1)})
        i_details.Add(New SampleDetail With {.DetailId = 0, .HeaderId = 0, .ItemId = 0, .Quantity = 1, .LastUpdate = Now})
        i_details.Add(New SampleDetail With {.DetailId = 1, .HeaderId = 3, .ItemId = 0, .Quantity = 1, .LastUpdate = Now})

        i_headers.Add(New SampleHeader With {.HeaderId = 1, .HeaderName = "とんがり", .LastUpdate = New Date(2018, 2, 1)})
        i_details.Add(New SampleDetail With {.DetailId = 2, .HeaderId = 1, .ItemId = 0, .Quantity = 3, .LastUpdate = Now})
        i_details.Add(New SampleDetail With {.DetailId = 3, .HeaderId = 1, .ItemId = 1, .Quantity = 3, .LastUpdate = Now})
        i_details.Add(New SampleDetail With {.DetailId = 4, .HeaderId = 1, .ItemId = 2, .Quantity = 3, .LastUpdate = Now})
        i_details.Add(New SampleDetail With {.DetailId = 5, .HeaderId = 1, .ItemId = 3, .Quantity = 3, .LastUpdate = Now})
        i_details.Add(New SampleDetail With {.DetailId = 6, .HeaderId = 1, .ItemId = 4, .Quantity = 3, .LastUpdate = Now})

        i_headers.Add(New SampleHeader With {.HeaderId = 2, .HeaderName = "きてれつ", .LastUpdate = New Date(2018, 1, 1)})
        i_details.Add(New SampleDetail With {.DetailId = 7, .HeaderId = 2, .ItemId = 0, .Quantity = 1, .LastUpdate = Now})

        i_headers.Add(New SampleHeader With {.HeaderId = 3, .HeaderName = "みよちゃん", .LastUpdate = New Date(2018, 1, 1)})
        i_details.Add(New SampleDetail With {.DetailId = 8, .HeaderId = 3, .ItemId = 0, .Quantity = 1, .LastUpdate = Now})
        i_details.Add(New SampleDetail With {.DetailId = 9, .HeaderId = 3, .ItemId = 1, .Quantity = 1, .LastUpdate = Now})
        i_details.Add(New SampleDetail With {.DetailId = 10, .HeaderId = 3, .ItemId = 2, .Quantity = 1, .LastUpdate = Now})
        i_details.Add(New SampleDetail With {.DetailId = 11, .HeaderId = 3, .ItemId = 3, .Quantity = 1, .LastUpdate = Now})
        i_details.Add(New SampleDetail With {.DetailId = 12, .HeaderId = 3, .ItemId = 4, .Quantity = 1, .LastUpdate = Now})

        i_headers.Add(New SampleHeader With {.HeaderId = 4, .HeaderName = "ころすけ", .LastUpdate = New Date(2018, 1, 1)})
    End Sub

    Sub Main(args As String())

        InitData()

        'データソース作成
        Dim Names = {"徳川家康", "織田信長", "徳川吉宗", "豊臣秀吉", "徳川慶喜"}

        'ラムダ式で「徳川」から始まるものだけを抽出する処理を定義
        Dim results = Names.Where(Function(name) name.StartsWith("徳川"))

        'ラムダ式を実行して結果を表示
        results.ToList.ForEach(Sub(name) Debug.WriteLine(name))


        Dim animals = {"アメンボ", "イノシシ", "ウマ", "エリマキトカゲ", "オオカミ"}
        Dim results2 = From animal In animals Where animal Like "*マ*"
        results2.ToList.ForEach(Sub(a) Debug.WriteLine(a))

        'Windowsフォルダー(例 C:\windows)のファイルの一覧
        Dim winFolder As New IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Windows))
        Dim fileList As IEnumerable(Of IO.FileInfo) = winFolder.EnumerateFiles

        'ファイルの名前とサイズを抽出
        Dim files = From file As IO.FileInfo In fileList
                    Select file.Name, file.Length

        'file は Nameプロパティ と Length プロパティだけを持つ匿名型です。
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
