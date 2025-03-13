import { Selector } from 'testcafe';

fixture `Calculator E2E Test`
    .page `http://localhost:3000`;

test('Perform Addition', async t => {
    await t
        .typeText('#num1', '10')
        .typeText('#num2', '5')
        .click('#operation-add')
        .click('#calculate-btn')
        .expect(Selector('#result').innerText).eql('15');
});
