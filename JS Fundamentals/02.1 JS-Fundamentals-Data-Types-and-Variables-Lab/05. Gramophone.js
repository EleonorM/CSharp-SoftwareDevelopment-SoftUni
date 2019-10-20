function plateRotationTime (bandName, albumName, songName){
    let songDurationInSeconds = (albumName.length * bandName.length) * songName.length / 2;
    let rotation = songDurationInSeconds / 2.5;
    console.log(`The plate was rotated ${Math.ceil(rotation)} times.`)
}

plateRotationTime('Black Sabbath', 'Paranoid', 'War Pigs')