# TGBot
## CommunicationMethods Class Documentation

The `CommunicationMethods` class is designed to handle various communication methods through a Telegram bot, utilizing the `ITelegramBotClient`. It provides methods to send different types of messages, including text, stickers, videos, audio, and location-based messages. Additionally, it can handle inline and reply keyboards for interaction with users.

### Constructor

```csharp
public CommunicationMethods(ITelegramBotClient _botClient, Update _update, CancellationToken _cancellationToken)
```

- **Parameters**:
  - `_botClient`: The Telegram bot client.
  - `_update`: The update received from the bot (typically contains message data).
  - `_cancellationToken`: A token to cancel operations if needed.

### Methods

---

#### TextButton

Sends a text message with an inline button.

```csharp
public async void TextButton(string text, string textButton, string url)
```

- **Parameters**:
  - `text`: The message text.
  - `textButton`: The button text.
  - `url`: The URL the button should lead to.

**Example**:

```csharp
commMethods.TextButton("Click the button below", "Visit Website", "https://example.com");
```

---

#### Text

Sends a plain text message.

```csharp
public async void Text(string text)
```

- **Parameters**:
  - `text`: The message text.

**Example**:

```csharp
commMethods.Text("Hello, World!");
```

---

#### Stickers

Sends a sticker from a URL.

```csharp
public async void Stickers(string url)
```

- **Parameters**:
  - `url`: The URL of the sticker.

**Example**:

```csharp
commMethods.Stickers("https://example.com/sticker.png");
```

---

#### Stickers_Local

Sends a sticker from a local file.

```csharp
public async void Stickers_Local(string url)
```

- **Parameters**:
  - `url`: The path to the local sticker file.

**Example**:

```csharp
commMethods.Stickers_Local("C:\\stickers\\sticker.png");
```

---

#### Video

Sends a video from a URL.

```csharp
public async void Video(string url)
```

- **Parameters**:
  - `url`: The URL of the video.

**Example**:

```csharp
commMethods.Video("https://example.com/video.mp4");
```

---

#### Video_Local

Sends a video from a local file.

```csharp
public async void Video_Local(string url)
```

- **Parameters**:
  - `url`: The path to the local video file.

**Example**:

```csharp
commMethods.Video_Local("C:\\videos\\video.mp4");
```

---

#### TextIMG_URL_HTML

Sends a photo with a caption in HTML format.

```csharp
public async void TextIMG_URL_HTML(string IMG, string HTML)
```

- **Parameters**:
  - `IMG`: The URL of the image.
  - `HTML`: The caption in HTML format.

**Example**:

```csharp
commMethods.TextIMG_URL_HTML("https://example.com/image.jpg", "<b>This is a bold caption</b>");
```

---

#### TextIMG_URL_HTML_Local

Sends a photo from a local file with a caption in HTML format.

```csharp
public async void TextIMG_URL_HTML_Local(string IMG, string HTML)
```

- **Parameters**:
  - `IMG`: The path to the local image file.
  - `HTML`: The caption in HTML format.

**Example**:

```csharp
commMethods.TextIMG_URL_HTML_Local("C:\\images\\image.jpg", "<b>This is a bold caption</b>");
```

---

#### Audio

Sends an audio file from a URL.

```csharp
public async void Audio(string mp3)
```

- **Parameters**:
  - `mp3`: The URL of the audio file.

**Example**:

```csharp
commMethods.Audio("https://example.com/audio.mp3");
```

---

#### Audio_Local

Sends an audio file from a local file.

```csharp
public async void Audio_Local(string mp3)
```

- **Parameters**:
  - `mp3`: The path to the local audio file.

**Example**:

```csharp
commMethods.Audio_Local("C:\\audios\\audio.mp3");
```

---

#### Video_Img

Sends a video with a thumbnail from URLs.

```csharp
public async void Video_Img(string url, string IMG)
```

- **Parameters**:
  - `url`: The URL of the video.
  - `IMG`: The URL of the thumbnail image.

**Example**:

```csharp
commMethods.Video_Img("https://example.com/video.mp4", "https://example.com/thumbnail.jpg");
```

---

#### Video_Img_Local

Sends a video with a local thumbnail image.

```csharp
public async void Video_Img_Local(string url, string IMG)
```

- **Parameters**:
  - `url`: The path to the local video file.
  - `IMG`: The path to the local thumbnail image.

**Example**:

```csharp
commMethods.Video_Img_Local("C:\\videos\\video.mp4", "C:\\images\\thumbnail.jpg");
```

---

#### Video360_Local

Sends a 360-degree video note from a local file.

```csharp
public async void Video360_Local(string mp4)
```

- **Parameters**:
  - `mp4`: The path to the local video file.

**Example**:

```csharp
commMethods.Video360_Local("C:\\videos\\video360.mp4");
```

---

#### PhotoArray

Sends an array of photos from URLs.

```csharp
public async void PhotoArray(string[] Photo)
```

- **Parameters**:
  - `Photo`: An array of photo URLs.

**Example**:

```csharp
commMethods.PhotoArray(new[] { "https://example.com/photo1.jpg", "https://example.com/photo2.jpg" });
```

---

#### PhotoArray_Local

Sends an array of photos from local files.

```csharp
public async void PhotoArray_Local(string[] Photo)
```

- **Parameters**:
  - `Photo`: An array of paths to local photos.

**Example**:

```csharp
commMethods.PhotoArray_Local(new[] { "C:\\photos\\photo1.jpg", "C:\\photos\\photo2.jpg" });
```

---

(Other methods such as `SurveyOpen`, `SurveyClose`, `Map`, and keyboard methods are documented similarly with examples).

