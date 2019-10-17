function printLanguage(country) {
    let language;
    switch (country) {
        case 'USA':
        case 'England':
            language = 'English';
            break;
        case 'Spain':
        case 'Mexico':
        case 'Argentina':
            language = 'Spanish'    
            break;
        default:
            language = 'unknown';
            break;
    }

    console.log(language);
    
}

printLanguage('Mexico')